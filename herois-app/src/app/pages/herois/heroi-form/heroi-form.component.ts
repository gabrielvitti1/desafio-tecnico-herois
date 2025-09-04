import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { HeroisService } from 'src/app/services/herois.service';
import { SuperpoderService } from 'src/app/services/superpoder.service';
import { Heroi } from 'src/app/models/heroi';
import { Superpoder } from 'src/app/models/superpoder';

@Component({
  selector: 'app-heroi-form',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule
  ],
  templateUrl: './heroi-form.component.html',
  styleUrls: ['./heroi-form.component.scss']
})
export class HeroiFormComponent implements OnInit {
  form!: FormGroup;
  editMode = false;
  heroiId?: number;
  superpoderes: Superpoder[] = [];
  private originalHeroi?: Heroi;

  constructor(
    private fb: FormBuilder,
    private service: HeroisService,
    private superpoderService: SuperpoderService,
    private route: ActivatedRoute,
    public router: Router
  ) {}

  ngOnInit(): void {
    this.form = this.fb.group({
      nome: ['', [Validators.required, Validators.maxLength(120)]],
      nomeHeroi: ['', [Validators.required, Validators.maxLength(120)]],
      dataNascimento: [null],
      altura: [null, Validators.required],
      peso: [null, Validators.required],
      superpoderesIds: [[]]
    });

    this.superpoderService.getSuperpoderes().subscribe(poderes => {
      this.superpoderes = poderes;
    });

    // verifica se é edição
    this.heroiId = Number(this.route.snapshot.paramMap.get('id'));
    if (this.heroiId) {
      this.editMode = true;
      this.service.getHeroiById(this.heroiId).subscribe(heroi => {
        this.originalHeroi = heroi;

        this.form.patchValue({
          nome: heroi.nome,
          nomeHeroi: heroi.nomeHeroi,
          dataNascimento: heroi.dataNascimento 
            ? new Date(heroi.dataNascimento).toISOString().substring(0, 10)
            : null,
          altura: heroi.altura,
          peso: heroi.peso,
          superpoderesIds: heroi.superpoderes?.map(p => p.id) || []
        });
      });
    }
  }

  private getChangedFields(original: any, updated: any): any {
    const changed: any = {};
    Object.keys(updated).forEach(key => {
      const originalValue = original[key];
      const updatedValue = updated[key];

      if (Array.isArray(updatedValue)) {
        if (JSON.stringify(updatedValue) !== JSON.stringify(originalValue)) {
          changed[key] = updatedValue;
        }
      } else if (updatedValue !== originalValue) {
        changed[key] = updatedValue;
      }
    });
    return changed;
  }

  salvar(): void {
    if (this.form.invalid) return;

    const formData = this.form.value;

    if (this.editMode && this.originalHeroi) {
      const changedData = this.getChangedFields(
        {
          ...this.originalHeroi,
          superpoderesIds: this.originalHeroi.superpoderes?.map(p => p.id) || []
        },
        formData
      );

      if (Object.keys(changedData).length === 0) {
        console.log('Nenhuma alteração detectada');
        return;
      }

      this.service.patchHero(this.heroiId!, changedData).subscribe(() => {
        this.router.navigate(['/herois']);
      });
    } else {
      this.service.createHero(formData).subscribe(() => {
        this.router.navigate(['/herois']);
      });
    }
  }
}
