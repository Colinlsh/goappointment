import React from 'react';
import ReactDOM from 'react-dom';

import { Card } from './UI/Card/Card';
import classes from './ErrorModal.module.css';
import AppointmentButton from './UI/Button/AppointmentButton';

interface BackdropProps {
  onConfirm: Function;
}
const Backdrop: React.FC<BackdropProps> = ({ onConfirm }) => {
  return <div className={classes.backdrop} onClick={() => onConfirm()} />;
};

interface ModalOverlayProps {
  title: string;
  message: string;
  onConfirm: Function;
}

const ModalOverlay: React.FC<ModalOverlayProps> = ({
  title,
  message,
  onConfirm,
}) => {
  return (
    <Card classname={classes.modal}>
      <header className={classes.header}>
        <h2>{title}</h2>
      </header>
      <div className={classes.content}>
        <p>{message}</p>
      </div>
      <footer className={classes.actions}>
        <AppointmentButton onPress={onConfirm}>Okay</AppointmentButton>
      </footer>
    </Card>
  );
};

interface ErrorModalProps {
  onConfirm: Function;
  title: string;
  message: string;
}

const ErrorModal: React.FC<ErrorModalProps> = ({
  title,
  message,
  onConfirm,
}) => {
  return (
    <React.Fragment>
      {ReactDOM.createPortal(
        <Backdrop onConfirm={onConfirm} />,
        document.getElementById('backdrop-root') as HTMLElement
      )}
      {ReactDOM.createPortal(
        <ModalOverlay title={title} message={message} onConfirm={onConfirm} />,
        document.getElementById('overlay-root') as HTMLElement
      )}
    </React.Fragment>
  );
};

export { ErrorModal };
