import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject, of } from 'rxjs';
import { tap } from 'rxjs/operators';

import { environment } from 'src/environments/environment';
import { IModel } from '../models/imodel';

export abstract class GenericApiCallService<Tdto extends IModel> {
  url: string;
  dtos$: BehaviorSubject<Map<string, Tdto>>  = new BehaviorSubject(new Map());

  constructor(
    private http: HttpClient,
    controllerUrl: string
  ) {
    this.url = `${environment.apiLink}/${controllerUrl}`;
   }

  public get(): Observable<Tdto[]> {
    if (!this.dtos$.value.size)
      return this.http.get<Tdto[]>(this.url)
        .pipe(
          tap(dtos => this.dtos$.next(this.arrayToMap(dtos)))
        );
       
    return of(Array.from(this.dtos$.value.values()));
  }
  
  public getById(id: string): Observable<Tdto> {
    if (!this.dtos$.value.size)
      return this.http.get<Tdto>(`${this.url}/${id}`);
      
    return of(this.dtos$.value.get(id));
  }

  public createOrUpdate(data: Tdto, id?: string) {
    var response = id ? this.update(id, data) : this.create(data);

    return response.pipe(
      tap(dto => {
        if (this.dtos$.value.size)
          this.dtos$.value.set(dto.id, dto);
      })
    );
  }
  
  public create(data: Tdto): Observable<Tdto> {
    return this.http.post<Tdto>(this.url, data);
  }

  public update(id: string, data: Tdto): Observable<Tdto> {
    return this.http.put<Tdto>(`${this.url}/${id}`, data);
  }

  public delete(id: string) {
    return this.http.delete(`${this.url}/${id}`)
      .pipe(
        tap(() => this.dtos$.value.delete(id)) 
      );
  }

  private arrayToMap(arr: Tdto[]): Map<string, Tdto> {
    var obj = arr.reduce(this.addElementToMap, {});

    return new Map(Object.entries(obj));
  }

  private addElementToMap(map: Map<string, Tdto>, element: Tdto): Map<string, Tdto> {
    map[element.id] = element

    return map;
  }
}
