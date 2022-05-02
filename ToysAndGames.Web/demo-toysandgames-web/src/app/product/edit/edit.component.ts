import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Product, ServiceResponseProduct } from '../product';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

  productId!: number;
  product!: Product;
  formProd!: FormGroup;

  constructor(
    public productService: ProductService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.productId = this.route.snapshot.params['productId'];
    this.productService.find(this.productId).subscribe((data: ServiceResponseProduct) => {

      if (data.hasError == false) {
        this.product = data.entity;
      } else {
        alert(data.error);
      }
    });

    this.formProd = new FormGroup({
      title: new FormControl('', [Validators.required]),
      body: new FormControl('', Validators.required),
      id: new FormControl(),
      name: new FormControl(),
      description: new FormControl(),
      company: new FormControl(),
      ageRestriction: new FormControl(),
      price: new FormControl()
    });

  }

  get f() {
    return this.formProd.controls;
  }

  submit() {
    this.productService.update(this.formProd.value).subscribe((res:any) => {
      console.log('Product updated successfully!');
      this.router.navigateByUrl('product/index');
    })
  }
}
