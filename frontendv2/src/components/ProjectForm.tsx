import React, { useState, useEffect } from "react";
import { Project, Status, Owner, Client } from "../types/project";
import { getOwners } from "../services/OwnerService";
import { getStatuses } from "../services/StatusService";
import { getClients } from "../services/ClientService";

interface ProjectFormProps {
   initialData?: Partial<Project>;
   onSave: (data: Partial<Project>) => void;
   onCancel: () => void;
}

const ProjectForm: React.FC<ProjectFormProps> = ({
   initialData = {},
   onSave,
   onCancel,
}) => {
   const [form, setForm] = useState<Partial<Project>>({
      ...initialData,
      statusId: initialData.statusId ?? 1,
   });

   const [owners, setOwners] = useState<Owner[]>([]);
   const [statuses, setStatuses] = useState<Status[]>([]);
   const [clients, setClients] = useState<Client[]>([]);

   useEffect(() => {
      getOwners().then(setOwners).catch(console.error);
      getStatuses().then(setStatuses).catch(console.error);
      getClients().then(setClients).catch(console.error);
   }, []);

   const handleChange = (
      e: React.ChangeEvent<
         HTMLInputElement | HTMLTextAreaElement | HTMLSelectElement
      >
   ) => {
      const { name, value } = e.target;
      setForm((prev) => ({
         ...prev,
         [name]: name === "budget" ? Number(value) : value,
      }));
   };

   const handleSubmit = (e: React.FormEvent) => {
      e.preventDefault();
      onSave(form);
   };

   return (
      <form onSubmit={handleSubmit} className="project-form">
         <input
            name="projectName"
            placeholder="Project Name"
            value={form.projectName || ""}
            onChange={handleChange}
            required
         />
         <textarea
            name="description"
            placeholder="Description"
            value={form.description || ""}
            onChange={handleChange}
            required
         />
         <input
            type="date"
            name="startDate"
            value={form.startDate?.toString().split("T")[0] || ""}
            onChange={handleChange}
            required
         />
         <input
            type="date"
            name="endDate"
            value={form.endDate?.toString().split("T")[0] || ""}
            onChange={handleChange}
            required
         />
         <input
            name="budget"
            type="number"
            placeholder="Budget"
            value={form.budget ?? ""}
            onChange={handleChange}
         />

         <select
            name="clientId"
            value={form.clientId ?? ""}
            onChange={handleChange}
            required
         >
            <option value="">Select Client</option>
            {clients.map((client) => (
               <option key={client.id} value={client.id}>
                  {client.clientName}
               </option>
            ))}
         </select>
         <select
            name="ownerId"
            value={form.ownerId ?? ""}
            onChange={handleChange}
            required
         >
            <option value="">Select Owner</option>
            {owners.map((owner) => (
               <option key={owner.id} value={owner.id}>
                  {owner.fullName}
               </option>
            ))}
         </select>

         {initialData?.id && (
            <select
               name="statusId"
               value={form.statusId ?? 1}
               onChange={handleChange}
               required
            >
               {statuses.map((status) => (
                  <option key={status.id} value={status.id}>
                     {status.statusName}
                  </option>
               ))}
            </select>
         )}
         <div className="button-row">
            <button type="submit">Save</button>
            <button type="button" onClick={onCancel}>
               Cancel
            </button>
         </div>
      </form>
   );
};

export default ProjectForm;
