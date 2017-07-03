import { SignInComponent, SignUpComponent } from "./index";

export const routs = [
    { path: "signin", component: SignInComponent },
    { path: "signup", component: SignUpComponent },
    { path: "", redirectTo: "signin", pathMatch: "full" }
];