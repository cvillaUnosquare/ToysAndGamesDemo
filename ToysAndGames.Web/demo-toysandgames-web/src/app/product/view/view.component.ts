import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Product, ServiceResponseProduct } from '../product';

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {
  productId!: number;
  product!: Product;

  constructor(
    public productService: ProductService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.productId = this.route.snapshot.params['productId'];
    console.log(this.productId);

    this.productService.find(this.productId).subscribe((data: ServiceResponseProduct) => {
      console.log(data);
      this.product = data.entity;
    });
  }

}
