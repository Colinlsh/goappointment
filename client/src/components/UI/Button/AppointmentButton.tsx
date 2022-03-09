import React, { ButtonHTMLAttributes, DetailedHTMLProps } from "react";
import "../../../css/style.css";

interface AppointmentButtonProps {
  buttonStyle?: React.CSSProperties;
  buttonCSSStyle?: string;
  isDisableRipple?: boolean | undefined;
  onPress: Function;
  buttonHTMLAttribute?: DetailedHTMLProps<
    ButtonHTMLAttributes<HTMLButtonElement>,
    HTMLButtonElement
  >;
  afterAction?: boolean | undefined;
}

export const buttonTypes = {
  submit: "submit",
  reset: "reset",
  button: "button",
};

const AppointmentButton = ({
  buttonStyle,
  buttonCSSStyle = "",
  onPress = () => {},
  buttonHTMLAttribute,
  afterAction = false,
  children,
}: React.PropsWithChildren<AppointmentButtonProps>) => {
  return (
    <button
      style={buttonStyle}
      className={`btn ${
        afterAction ? "" : "btn__no-afterAction"
      } ${buttonCSSStyle}`}
      onClick={() => onPress()}
      {...buttonHTMLAttribute}
    >
      {children}
    </button>
  );
};

export default AppointmentButton;
