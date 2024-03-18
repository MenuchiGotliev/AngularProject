import { FormControl, ValidatorFn, Validators } from '@angular/forms';

const passwordValidator = (): ValidatorFn => {
  return (control: FormControl) => {
    const value: string = control.value;
    
    // בדיקת תקינות הסיסמה
    const hasLowerCase = /[a-z]/.test(value);
    const hasUpperCase = /[A-Z]/.test(value);
    const hasNumber = /\d/.test(value);
    const hasSpecialChar = /[!@#$%^&*(),.?":{}|<>]/.test(value);
    
    // בדיקה אם כל התנאים מתקיימים
    const isValid = hasLowerCase && hasUpperCase && hasNumber && hasSpecialChar;

    // החזרת הולידציה בהתאם לתוצאה
    return isValid ? null : { invalidPassword: true };
  };
};

// השימוש בוולידטור
export const password = passwordValidator();
