import React from "react";
import { Project } from "../../types/project";

interface Props {
   project: Project;
   onClose: () => void;
}

const ProjectDetailsModal: React.FC<Props> = ({ project, onClose }) => {
   return (
      <div className="modal-backdrop" onClick={onClose}>
         <div className="modal-content" onClick={(e) => e.stopPropagation()}>
            <h2>{project.projectName}</h2>
            <p>{project.description}</p>
            <p>Start: {new Date(project.startDate).toLocaleDateString()}</p>
            <p>End: {new Date(project.endDate).toLocaleDateString()}</p>
            <p>Budget: ${project.budget ?? "N/A"}</p>
            <p>Status: {project.status?.statusName ?? "N/A"}</p>
            <p>Client: {project.client?.clientName ?? "N/A"}</p>
            <p>Owner: {project.owner?.fullName ?? "N/A"}</p>

            <button onClick={onClose}>Close</button>
         </div>
      </div>
   );
};

export default ProjectDetailsModal;
