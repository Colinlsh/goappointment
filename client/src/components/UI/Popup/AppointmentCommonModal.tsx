import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { toggleCommonModal } from '../../../app/redux/slice/applicationSlice';
import { RootState } from '../../../app/redux/store';
import '../../../css/style.css';
import AppointmentButton from '../Button/AppointmentButton';

interface AppointmentCommonModalProps {
  title?: string | undefined;
  message?: string | undefined;
  isVisible?: boolean;
}

const AppointmentCommonModal: React.FC<AppointmentCommonModalProps> = () => {
  // #region Redux
  const { commonModal } = useSelector((state: RootState) => state.application);
  var dispatch = useDispatch();
  // #endregion

  return (
    <div className={`popup ${commonModal.isVisible ? '' : 'popup__close'}`}>
      <div className="popup__content">
        <div className="popup__title">{commonModal.title}</div>
        <div className="popup__message-button">
          {commonModal.message
            .filter((x) => x.message !== null)
            .map((x) => (
              <div className="popup__message">
                {x.field}: {x.message}
              </div>
            ))}

          <div className="popup__button-container">
            <AppointmentButton
              onPress={() => {
                dispatch(toggleCommonModal(!commonModal.isVisible));
              }}
              buttonCSSStyle={'popup__button'}
            >
              Ok
            </AppointmentButton>
          </div>
        </div>
      </div>
    </div>
  );
};

export { AppointmentCommonModal };
