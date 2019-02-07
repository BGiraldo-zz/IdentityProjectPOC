import { Component, OnInit } from '@angular/core';
import { Product } from '../models/Product';
import { ProductService } from './product.service';
import { Token } from '../models/Token';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  products: Product[] = [];
  token: Token;

  constructor(public productService: ProductService) {
    this.token = new Token();
  }

  getToken() {
    this.productService.getAntiForgeryToken().subscribe(data => {
      console.log(data);
   //   if (this.token.cookieToken.length != 0) {
        this.token = data;
        console.log(data.cookieToken);
        console.log(data.formToken);
//}
    });
  }

  getProducts() {
    // if (this.token.cookieToken.length != 0) {
    this.productService.getProducts(this.token).subscribe(data => {
        console.log(data);
        if (data.length !== 0) {
          this.products = data["obj"];
        }
      });
  //  }
  }

}
