import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PersonService } from '../../services/person.service';
import { switchMap, take } from 'rxjs/operators';
import { of } from 'rxjs';
import { Person } from '../../interfaces/person';
import { CityService } from '../../services/city.service';
import { City } from '../../interfaces/city';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-person-form',
  templateUrl: './person-form.component.html',
  styleUrls: ['./person-form.component.scss']
})
export class PersonFormComponent implements OnInit {

  personModel: FormGroup = new FormGroup({
    id: new FormControl(0, Validators.required),
    name: new FormControl('', Validators.required),
    age: new FormControl('', [Validators.required, Validators.max(50), Validators.min(0) ]),
    document: new FormControl('', Validators.required),
    cityId: new FormControl(null, Validators.required),
  });

  cities: City[] = [];

  constructor(private personService: PersonService,
    private cityService: CityService,
    private router: Router,
    private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.route.paramMap.pipe(
      switchMap((params) => {
        let id = params.get('id') ?? '';
        if (!id) return of();
        return this.personService.getById(Number(id));
      }), take(1)).subscribe(response => {
        if (!response) return;
        let person: Person = {
          id: response.id,
          name: response.name,
          document: response.document,
          age: response.age,
          cityId: response.cityId
        };
        this.personModel.setValue(person);
      });
    this.cityService.get().pipe(take(1)).subscribe(response => {
      this.cities = response;
    });
  }

  save() {
    if (this.personModel.invalid) {
      for (const control of Object.keys(this.personModel.controls)) {
        this.personModel.controls[control].markAsTouched();
      }
      return;
    }

    if (!this.personModel.value.id)
      this.personService.create(this.personModel.value).subscribe(
        response => {
          if (response.success) {
            this.router.navigate(['']);
          } else {
            console.log(response)
            Swal.fire({text: response.error.error});  
          }
        },
        response => {
          console.log(response)
          Swal.fire({text: response.error.error});
        }
      );
    else
      this.personService.update(this.personModel.value).subscribe(
        response => {
          if (response.success) {
            this.router.navigate(['']);
          } else {
            console.log(response)
            Swal.fire({text: response.error.error});  
          }
        },
        response => {
          console.log(response)
          Swal.fire({text: response.error.error});
        }
      );
  }

  cancel() {
    this.router.navigate(['']);
  }

}
