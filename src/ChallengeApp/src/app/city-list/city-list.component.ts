import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { take } from 'rxjs/operators';
import Swal from 'sweetalert2';
import { City } from '../../interfaces/city';
import { CityService } from '../../services/city.service';

@Component({
  selector: 'app-city-list',
  styleUrls: ['./city-list.component.scss'],
  templateUrl: './city-list.component.html'
})
export class CityListComponent {

  public cities: City[] = [];
  filter = {
    id: null,
    name: '',
    document: '',
    age: null
  };

  constructor(private cityService: CityService,
    private router: Router) {
    this.cityService.get(this.filter).pipe(take(1)).subscribe((result: any) => {
      this.cities = result;
    }, error => console.error(error));
  }

  search() {
    this.cityService.get(this.filter).pipe(take(1)).subscribe((result: any) => {
      this.cities = result;
    }, error => console.error(error));
  }

  addRecordClick() {
    this.router.navigate(['form-city']);
  }

  editClick(id: number) {
    this.router.navigate([`form-city`, { id }]);
  }

  deleteClick(id: number) {
    Swal.fire({
      title: 'Are you sure?',
      text: "You won't be able to revert this!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result: any) => {
      if (result.isConfirmed) {
        this.cityService.delete(id).subscribe((response: any) => {
          if (response.success)
            Swal.fire(
              'Deleted!',
              'The record has been deleted.',
              'success'
            )
          else
            Swal.fire(
              'Erro!',
              response.message,
              'error'
            )
          this.cityService.get(this.filter).pipe(take(1)).subscribe((result: any) => {
            this.cities = result;
          }, error => console.error(error));
        })
      }
    })
  }
}

