import React from "react";
import { ReactComponent as Facebook } from "../assets/facebook1.svg";
import { ReactComponent as Instagram } from "../assets/instagram1.svg";
import { ReactComponent as Whatsapp } from "../assets/whatsapp1.svg";
import { ReactComponent as Phone } from "../assets/phone.svg";
import { ReactComponent as Location } from "../assets/location2.svg";
import "../css/style.css";

const Footer = () => {
  return (
    <div className="footer">
      <div className="footer__container">
        <div className="footer__address">
          <span className="footer__label">Address</span>

          <div className="footer__label-container">
            <Location className="footer__socials-item noselect" />
            <span className="footer__label footer__label-thin">
              ADDRESS ADDRESSS
            </span>
          </div>
        </div>

        <div className="footer__contact-us">
          <span className="footer__label">Contact us</span>
          <div className="footer__label-container">
            <Phone className="footer__socials-item noselect" />
            <span className="footer__label footer__label-medium">
              +65 9999999
            </span>
          </div>
        </div>

        <div className="footer__socials">
          <span className="footer__label">Follow us</span>
          <div className="footer__label-container">
            <Facebook className="footer__socials-item noselect" />
            <span className="footer__label footer__label-thin">Facebook</span>
          </div>
          <div className="footer__label-container">
            <Instagram className="footer__socials-item noselect" />
            <span className="footer__label footer__label-thin">Instagram</span>
          </div>
          <div className="footer__label-container">
            <Whatsapp className="footer__socials-item noselect" />
            <span className="footer__label footer__label-thin">Whatsapp</span>
          </div>
        </div>
      </div>
    </div>
  );
};

export { Footer };
