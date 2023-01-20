import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ServiceService } from 'src/app/service.service';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css'],
})
export class AddComponent implements OnInit {
  add: any;
  constructor(
    private ds: ServiceService,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  ngOnInit(): void {
    console.log(this.data);
    this.add = new FormGroup({
      ReservationId: new FormControl(''),
      Hotel: new FormControl(''),
      Arrival: new FormControl(''),
      Departure: new FormControl(''),
      Type: new FormControl(''),
      Guest: new FormControl(''),
      Price: new FormControl(''),
    });

    let Adate = this.data.Arrival.split('T');
    let Ddate = this.data.Departure.split('T');
    this.add.patchValue({
      ReservationId: this.data.ReservationId,
      Hotel: this.data.Hotel,
      Arrival: Adate[0],
      Departure: Ddate[0],
      Type:this.data.Type,
      Guest: this.data.Guest,
      Price:this.data.Price,
    });
  }

  save() {
    console.log(this.add.value);
    let serializedForm = JSON.stringify(this.add.value);
    console.log(serializedForm);
    this.ds.postData(serializedForm);
    window.location.reload();
  }

  Cancelbtn(a:any){
    console.log(a)

  }
}
