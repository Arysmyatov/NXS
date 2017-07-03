import { PublicationsComponent, PublicationItemComponent } from "./index";

export const routs = [
    { path: "publications", component: PublicationItemComponent },
    { path: "", redirectTo: "publications", pathMatch: "full" }
];