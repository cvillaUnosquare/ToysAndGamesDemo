import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators, FormBuilder, AbstractControl} from '@angular/forms';
import { Product } from '../product';
import { NotifierService } from 'angular-notifier';
      
@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {
     
  formProd: FormGroup = new FormGroup({
    id: new FormControl(),
      name: new FormControl(),
      description: new FormControl(),
      company: new FormControl(),
      ageRestriction: new FormControl(),
      price: new FormControl()
  });
  product!: Product;
  private readonly notifier: NotifierService;
  submitted = false;
     
  /*------------------------------------------
  --------------------------------------------
  Created constructor
  --------------------------------------------
  --------------------------------------------*/
  constructor(
    public productService: ProductService,
    private router: Router,
    notifierService: NotifierService,
    private formBuilder: FormBuilder
  ) { 
    this.notifier = notifierService;
  }
     
  /**
   * Write code on Method
   *
   * @return response()
   */
  ngOnInit(): void {
    this.formProd = this.formBuilder.group({
      name: ['', 
      [
        Validators.required,
        Validators.maxLength(50)
      ]],
      description: ['',
      [
        Validators.required,
        Validators.maxLength(100)
      ]],
      company: ['',
      [
        Validators.required,
        Validators.maxLength(50)
      ]],
      price: ['', 
      [
        Validators.required,
        Validators.min(0),
        Validators.max(1000)
      ]]
    });
  }
     
  /**
   * Write code on Method
   *
   * @return response()
   */
  get f(): {[key: string]: AbstractControl }{
    return this.formProd.controls;
  }
     
  /**
   * Write code on Method
   *
   * @return response()
   */
  submit(){
    this.submitted = true;
    if(this.formProd.invalid){
      return;
    }

    this.formProd.controls['id'].setValue(0);
    
    this.productService.create(this.formProd.value).subscribe((res:any) => {
          if (res.hasError == false) {
            
            this.router.navigateByUrl('product/index');
            this.notifier.notify('success', 'The product was created!');
          } else {
            this.notifier.notify('error', 'A problem has ocurred! ' + res.error);
          }
    })
  }

  onReset(): void {
    this.submitted = false;
    this.formProd.reset();
  }
   
}