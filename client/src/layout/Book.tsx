import { FormikProps } from "formik";
import { useRef } from "react";

import { Calendar, Timeslot } from "../components/UI";
import AppointmentButton from "../components/UI/Button/AppointmentButton";
import {
  AppointmentForm,
  InitialFormValues,
} from "../components/UI/Form/AppointmentForm";
import "../css/style.css";

const Book = () => {
  const formRef = useRef<FormikProps<InitialFormValues>>(null);

  return (
    <div className="book">
      <div className="book__group">
        <div className="book__calendar-form">
          {/* <div className="book__calendar-container">
            <label className="book__label">Select Date</label>
            <Calendar />
          </div> */}
          <div className="book__form-container">
            <div className="book__form">
              <AppointmentForm formRef={formRef} />
            </div>
          </div>
        </div>

        {/* <div className="book__button-container">
          <AppointmentButton
            buttonCSSStyle="book__button"
            buttonHTMLAttribute={{ type: 'submit' }}
            onPress={() => {
              formRef.current?.handleSubmit();
            }}
          >
            Book
          </AppointmentButton>
        </div> */}
      </div>
    </div>
  );
};

export { Book };
