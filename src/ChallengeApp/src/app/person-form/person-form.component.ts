import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PersonService } from '../../services/person.service';
import { switchMap, take } from 'rxjs/operators';
import { of } from 'rxjs';
import { Person } from '../../interfaces/person';
import { CityService } from '../../services/city.service';
import { City } from '../../interfaces/city';

@Component({
  selector: 'app-person-form',
  templateUrl: './person-form.component.html',
  styleUrls: ['./person-form.component.scss']
})
export class PersonFormComponent implements OnInit {

  personModel: FormGroup = new FormGroup({
    id: new FormControl(0, Validators.required),
    name: new FormControl('', Validators.required),
    age: new FormControl('', Validators.required),
    document: new FormControl('', Validators.required),
    cityId: new FormControl(0, Validators.required),
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
    if (!this.personModel.valid) return;
    if (!this.personModel.value.id)
      this.personService.create(this.personModel.value).subscribe(
        response => {
          //TODO: user feedback
          if (response.success) {
            this.router.navigate(['']);
          }
        },
        error => {
          console.log(error)
          //TODO: user feedback
        }
      );
    else
      this.personService.update(this.personModel.value).subscribe(
        response => {
          //TODO: user feedback
          if (response.success) {
            this.router.navigate(['']);
          }
        },
        error => {
          console.log(error)
          //TODO: mensagem
        }
      );
  }

  cancel() {
    this.router.navigate(['']);
  }

}
