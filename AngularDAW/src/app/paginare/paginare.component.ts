import { Component } from '@angular/core';

@Component({
  selector: 'app-paginare',
  templateUrl: './paginare.component.html',
  styleUrls: ['./paginare.component.scss']
})
export class PaginareComponent {
  currentPage: number = 1;
  totalPages: number = 5;

  previousPage() {
    if (this.currentPage > 1) {
      this.currentPage--;
    }
  }

  nextPage() {
    if (this.currentPage < this.totalPages) {
      this.currentPage++;
    }
  }
}
