import { AbstractControl, AsyncValidatorFn, FormGroup } from "@angular/forms";
import { of } from "rxjs";

export function ConfirmPassValdiator(fg: FormGroup): AsyncValidatorFn {
    return (control: AbstractControl) => of(
        fg.controls['Password'].value != control.value ? 
            {"match": {value: control.value}} : null
    );
}