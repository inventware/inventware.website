import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-carousel',
  templateUrl: './carousel.component.html',
  styleUrls: ['./carousel.component.css']
})
export class CarouselComponent implements OnInit {
  banners: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getBanners();
  }

  getBanners() {
    this.http.get('https://localhost:44337/api/banners').subscribe(response => {
      this.banners = response;
      console.log(response);
      }, error => {
        console.log('(FHC) Houve um erro -->' + error);
      }
    );
  }

}
