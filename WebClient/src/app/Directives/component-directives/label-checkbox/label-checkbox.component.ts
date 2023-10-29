import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-label-checkbox',
  templateUrl: './label-checkbox.component.html',
  styleUrls: ['./label-checkbox.component.css']
})
export class LabelCheckboxComponent {
  @Input() label: string = '';
  IsFocused: boolean = false;

  IsChecked(): void {
    this.IsFocused = !this.IsFocused;
  }
  hoverEffect(event: MouseEvent): void {
    const imgElement = (event.currentTarget as HTMLDivElement).querySelector('img')!;
    if (!this.IsFocused) {
      imgElement.style.filter = 'grayscale(0%)';
    }
  }
  hoverEffectEnd(event: MouseEvent): void {
    const imgElement = (event.currentTarget as HTMLDivElement).querySelector('img')!;
    if (!this.IsFocused) {
      imgElement.style.filter = 'grayscale(100%)';
    }
    else {
      imgElement.style.filter = 'grayscale(0%)';

    }
  }
  addWorkout(){
    // if
  }
}
