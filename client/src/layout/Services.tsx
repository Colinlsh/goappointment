import React, { FC } from "react";
import "../css/style.css";
import servicelogo_1 from "../assets/font.svg";
import servicelogo_2 from "../assets/omega.svg";
import servicelogo_3 from "../assets/sigma.svg";

interface ServicesProps {
  servicesRef?: React.MutableRefObject<HTMLDivElement | null> | null;
}

const Services: FC<ServicesProps> = ({ servicesRef = null }) => {
  return (
    <div ref={servicesRef} className="services">
      <div className="services__overview">
        <div className="services__header-container">
          <label htmlFor="#" className="services__header heading-primary">
            SERVICES
          </label>
        </div>
        <div className="services__overview-logo-container">
          <div className="services__overview-item">
            <div className="services__overview-logo">
              <img
                src={servicelogo_1}
                alt="logo1"
                className="services__list-item-logo"
              />
            </div>
            <label className="services__overview-text">SERVICE 1</label>
          </div>
          <div className="services__overview-item">
            <div className="services__overview-logo">
              <img
                src={servicelogo_2}
                alt="logo2"
                className="services__list-item-logo"
              />
            </div>
            <label className="services__overview-text">SERVICE 2</label>
          </div>
          <div className="services__overview-item">
            <div className="services__overview-logo">
              <img
                src={servicelogo_3}
                alt="logo3"
                className="services__list-item-logo"
              />
            </div>
            <label className="services__overview-text">SERVICE 3</label>
          </div>
        </div>
      </div>
      <div className="services__list">
        <div className="services__list-item">
          <div className="services__logo-container">
            <img
              src={servicelogo_1}
              alt="logo1"
              className="services__list-item-logo"
            />
          </div>
          <div className="services__list-item-description">
            <label className="services__overview-text">SERVICE 1</label>
          </div>
        </div>
        <div className="services__list-item services__alternate">
          <div className="services__logo-container">
            <img
              src={servicelogo_2}
              alt="logo2"
              className="services__list-item-logo"
            />
          </div>
          <div className="services__list-item-description">
            <label className="services__overview-text">SERVICE 2</label>
          </div>
        </div>
        <div className="services__list-item">
          <div className="services__logo-container">
            <img
              src={servicelogo_3}
              alt="logo3"
              className="services__list-item-logo"
            />
          </div>
          <div className="services__list-item-description">
            <label className="services__overview-text">SERVICE 3</label>
          </div>
        </div>
      </div>
    </div>
  );
};

export { Services };
