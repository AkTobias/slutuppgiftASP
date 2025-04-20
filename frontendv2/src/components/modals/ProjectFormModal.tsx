import { Project } from "../../types/project";
import ProjectForm from "../ProjectForm";
import "./ProjectFormModal.css";

interface Props {
   initialData?: Partial<Project>;
   onClose: () => void;
   onSave: (data: Partial<Project>) => void;
}

const ProjectFormModal: React.FC<Props> = ({
   initialData,
   onClose,
   onSave,
}) => {
   return (
      <div className="modal-backdrop" onClick={onClose}>
         <div className="modal-content" onClick={(e) => e.stopPropagation()}>
            <h2>{initialData?.id ? "Edit Project" : "New Project"}</h2>
            <ProjectForm
               initialData={initialData}
               onSave={(data) => {
                  onSave(data);
                  onClose();
               }}
               onCancel={onClose}
            />
         </div>
      </div>
   );
};

export default ProjectFormModal;
