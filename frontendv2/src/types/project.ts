export interface Status {
    id: number;
    statusName: string;
 }
 
 export interface Client {
    id: number;
    clientName: string;
 }
 
 export interface Owner {
    id: number;
    fullName: string;
 }
 
 
 export interface Project {
    id: string;
    projectName: string;
    description: string;
    startDate: Date;
    endDate: Date;
    budget: number | null;
    statusId: number;
    clientId: number;
    ownerId: number;
    status?: Status; 
    client?: Client; 
    owner?: Owner; 
 }

 export type NewProject = {
    projectName: string;
    description: string;
    startDate: string;
    endDate: string;
    budget: number;
    clientId: number;
    ownerId: number;
    statusId: number;
 }