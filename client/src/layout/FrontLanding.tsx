import React from "react";
import "../css/style.css";
import { ReactComponent as Logo3 } from "../assets/colintech-1-nobackground.svg";
import { ReactComponent as Facebook } from "../assets/facebook1.svg";
import { ReactComponent as Instagram } from "../assets/instagram1.svg";
import { ReactComponent as Whatsapp } from "../assets/whatsapp1.svg";
import AppointmentButton from "../components/UI/Button/AppointmentButton";
import { useHistory } from "react-router-dom";
import { locationState } from "../app/models";

interface FrontLandingProps {
  frontlandingRef: React.MutableRefObject<HTMLDivElement | null> | null;
}

const FrontLanding: React.FC<FrontLandingProps> = ({ frontlandingRef }) => {
  let history = useHistory();
  return (
    <div ref={frontlandingRef} className="frontlanding">
      <div className="frontlanding__title-button-container">
        <div className="frontlanding__title-container">
          <h1 className="frontlanding__title heading-primary">COLIN TECH</h1>
        </div>
        <div className="frontlanding__button-container">
          <AppointmentButton
            afterAction={true}
            onPress={() =>
              history.push("/goappointment/book", {
                from: {
                  pathname: history.location.pathname,
                  ref: null,
                },
              } as locationState)
            }
            buttonCSSStyle="btn--pinkish frontlanding__bookbutton"
          >
            <span className="frontlanding__bookbutton-text noselect">
              Book Appointment
            </span>
          </AppointmentButton>
        </div>
      </div>

      <div className="frontlanding__logo-socials-container">
        <div onClick={() => {}} className="frontlanding__logo3-container">
          <Logo3 className="frontlanding__logo3" />
        </div>
        <div className=" frontlanding__button-container-smallscreen">
          <AppointmentButton
            onPress={() => history.push("/goappointment/book")}
            buttonCSSStyle="frontlanding__bookbutton-smallscreen btn--pinkish frontlanding__bookbutton "
          >
            <span className="frontlanding__bookbutton-text noselect">
              Book Appointment
            </span>
          </AppointmentButton>
        </div>
        <div className="frontlanding__socials-container">
          <div className="frontlanding__socials-list">
            <Facebook className="frontlanding__socials-item noselect" />
            <Instagram className="frontlanding__socials-item noselect" />
            <Whatsapp className="frontlanding__socials-item noselect" />
          </div>
        </div>
      </div>
    </div>
  );
};

export { FrontLanding };
