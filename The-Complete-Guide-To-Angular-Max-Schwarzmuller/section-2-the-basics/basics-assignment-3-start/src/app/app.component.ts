import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  styles: [
    `
      .green-text {
        color: green;
      }
    `,
  ],
})
export class AppComponent {
  passwordHidden = true;
  buttonClicks = [];
  logButtonClicks() {
    this.buttonClicks.push(
      this.buttonClicks.length < 1
        ? 1
        : this.buttonClicks[this.buttonClicks.length - 1] + 1
    );
  }

  getBtnBgColor(button) {
    return button > 4 ? 'orange' : 'white';
  }

  btnGreenText(button) {
    return button > 4;
  }
}
