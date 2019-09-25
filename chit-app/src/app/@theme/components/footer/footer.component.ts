import { Component } from '@angular/core';

@Component({
  selector: 'ngx-footer',
  styleUrls: ['./footer.component.scss'],
  template: `
    <span class="created-by">Created with ♥ by <b><a href="https://szymanski.io" target="_blank">Szymen</a></b> 2019</span>
  `,
})
export class FooterComponent {
}
