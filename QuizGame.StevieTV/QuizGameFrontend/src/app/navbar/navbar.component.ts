import { Component } from '@angular/core';
import { MatButton } from "@angular/material/button";
import {MatToolbarModule} from '@angular/material/toolbar';
import { RouterLink } from "@angular/router";

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [MatToolbarModule, MatButton, RouterLink],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {

}
