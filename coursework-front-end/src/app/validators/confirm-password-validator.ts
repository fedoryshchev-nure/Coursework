import { FormGroup } from "@angular/forms";

const pass = 'Password';
const confPass = 'ConfirmPassword';

export function ConfirmPassValdiator(fg: FormGroup) {
    const passControl = fg.controls[pass];
    const confPassControl = fg.controls[confPass];

    if (confPassControl.errors)
        return;

    if (passControl.value != confPassControl.value) {
        confPassControl.setErrors(
            {"match": true }
        );
    }
}