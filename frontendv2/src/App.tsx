import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { ProjectsProvider } from "./contexts/ProjectsProvider";
import ProjectsList from "./pages/projects/ProjectList.tsx/ProjectsList";
import Layout from "./pages/layouts/Layout";

const App: React.FC = () => {
   return (
      <ProjectsProvider>
         <BrowserRouter>
            <Routes>
               <Route path="/" element={<Layout />}>
                  <Route index element={<ProjectsList />} />
                  {/* You can add more routes here */}
               </Route>
            </Routes>
         </BrowserRouter>
      </ProjectsProvider>
   );
};

export default App;
