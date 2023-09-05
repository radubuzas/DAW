import { Component } from '@angular/core';

@Component({
  selector: 'app-shopping',
  templateUrl: './shopping.component.html',
  styleUrls: ['./shopping.component.scss']
})
export class ShoppingComponent implements OnInit {

  items: string[] = ['Măr', 'Banane', 'Pâine', 'Lapte'];

  constructor() { }

  ngOnInit(): void {
  }

}
