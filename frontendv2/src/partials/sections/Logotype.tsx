import React from "react";
import { Link } from "react-router-dom";
import alphaLogo from "../../assets/alpha-logotype.svg";

const Logotype: React.FC = () => {
   return (
      <Link to="/" className="logotype">
         <img src={alphaLogo} alt="Alpha Logotype" />
         <span>alpha</span>
      </Link>
   );
};

export default Logotype;
