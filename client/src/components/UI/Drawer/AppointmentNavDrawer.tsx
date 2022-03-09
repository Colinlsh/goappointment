import React, { useState, FC } from "react";
import "../../../css/style.css";
import AppointmentButton from "../Button/AppointmentButton";
import logo4 from "../../../assets/colintech/colintech-1-nobackground2.png";
import { useHistory, useLocation } from "react-router-dom";
import { locationState } from "../../../app/models";
import LinkedInIcon from "@mui/icons-material/LinkedIn";

interface AppointmentNavDrawerProps {
  servicesRef: React.MutableRefObject<HTMLDivElement | null>;
  frontLandingRef: React.MutableRefObject<HTMLDivElement | null>;
}

const AppointmentNavDrawer: FC<AppointmentNavDrawerProps> = ({
  servicesRef,
  frontLandingRef,
}) => {
  const [openDrawer, setOpenDrawer] = useState(false);
  const history = useHistory();
  const location = useLocation();

  const scrollTo = (ref: React.MutableRefObject<HTMLDivElement | null>) => {
    ref.current?.scrollIntoView({
      behavior: "smooth",
      block: "start",
      inline: "nearest",
    });
  };

  return (
    <div className="navigation">
      <div className="navigation__logo-container">
        <AppointmentButton
          onPress={() => {
            if (location.pathname === "/goappointment/") {
              scrollTo(frontLandingRef);
            } else {
              history.push("/goappointment/", {
                from: {
                  pathname: history.location.pathname,
                  ref: frontLandingRef,
                },
              } as locationState);
            }
          }}
          buttonCSSStyle="navigation__logo"
        >
          <img src={logo4} className="navigation__logo-photo" alt="new" />
        </AppointmentButton>
        <AppointmentButton
          onPress={() => {
            window.open(
              "https://www.linkedin.com/in/colinlsh88888888/",
              "_blank"
            ); //to open new page
          }}
          buttonCSSStyle="navigation__findmehere"
        >
          <div style={{ alignSelf: "center" }}>COLIN | FIND ME ON LINKEDIN</div>
          <LinkedInIcon style={{ alignSelf: "center" }} />
        </AppointmentButton>
      </div>

      <div className="navigation__menu-container">
        <ul className="navigation__list">
          <li className="navigation__item">
            <div onClick={() => {}} className="navigation__otherbutton">
              <span className="paragraph navigation__otherbutton-text noselect">
                About
              </span>
            </div>
          </li>
          <li className="navigation__item">
            <div
              onClick={() => {
                if (location.pathname === "/goappointment/") {
                  scrollTo(servicesRef);
                } else {
                  history.push("/goappointment/", {
                    from: {
                      pathname: history.location.pathname,
                      ref: servicesRef,
                    },
                  } as locationState);
                }
              }}
              className="navigation__otherbutton"
            >
              <span className="paragraph navigation__otherbutton-text noselect">
                Services
              </span>
            </div>
          </li>
          <li className="navigation__item">
            <AppointmentButton
              onPress={() =>
                history.push("/goappointment/book", {
                  from: {
                    pathname: history.location.pathname,
                    ref: null,
                  },
                } as locationState)
              }
              buttonCSSStyle="btn--pinkish navigation__bookbutton"
            >
              <span className="navigation__bookbutton-text noselect">
                Book Appointment
              </span>
            </AppointmentButton>
          </li>
        </ul>
      </div>
      <div
        className="navigation__side-drawer"
        onClick={() => setOpenDrawer(!openDrawer)}
      >
        <label className="navigation__button">
          <span className="navigation__icon">&nbsp;</span>
        </label>
        <div
          className={`navigation__background ${
            openDrawer ? "navigation__backgroundOpen" : ""
          }`}
        >
          &nbsp;
        </div>
      </div>
    </div>
  );
};

export { AppointmentNavDrawer };
