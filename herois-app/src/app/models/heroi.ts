import { Superpoder } from "./superpoder";

export interface Heroi {
  id: number;
  nome: string;
  nomeHeroi: string;
  dataNascimento?: string; // Date no backend vira string no frontend
  altura: number;
  peso: number;
  superpoderes: Superpoder[];
}
