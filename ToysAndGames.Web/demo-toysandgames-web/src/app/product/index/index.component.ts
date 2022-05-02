import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';
import { Product } from '../product';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {
  products: Product[] = [];
  constructor(public productService: ProductService) { }

  ngOnInit(): void {
    this.productService.getAll().subscribe((data: Product[]) => {
      this.products = data;
    })
  }

  deletePost(productId: number){
    this.productService.delete(productId).subscribe(res => {
      this.products = this.products.filter(item => item.id !== productId);
      console.log('Post deleted successfully!');
    })
  }
}
