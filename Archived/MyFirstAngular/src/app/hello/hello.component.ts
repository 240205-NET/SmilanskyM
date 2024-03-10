import { Component } from '@angular/core';

@Component({
  selector: 'app-hello',
  templateUrl: './hello.component.html',
  styleUrls: ['./hello.component.css'],
})
export class HelloComponent {
  isTrue: Boolean = true;
  showPets: Boolean = true;
  pets: string[] = ['Fat Yoshi', 'Fat Yoshi Jr.', 'Fat Yoshi Jr. 2'];
  attrBinding: string = 'container';
  negateIsTrue(): void {
    this.isTrue = !this.isTrue;
  }
  negateShowPets(): void {
    this.showPets = !this.showPets;
  }
}
