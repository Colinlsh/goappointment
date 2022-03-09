import React, { ChangeEvent, useEffect, useState } from "react";
import { FormikProps, useFormik } from "formik";
import "../../../css/style.css";
import AppointmentButton from "../Button/AppointmentButton";
import { bookAppointmentSchema } from "../../../utils/schema/appointmentSchema";
import { ReactComponent as Warning } from "../../../assets/warning.svg";
import { Calendar, Timeslot } from "..";
import { useDispatch, useSelector } from "react-redux";
import { setCommonModal } from "../../../app/redux/slice/applicationSlice";
import { CommonModal, ModalErrorModel } from "../../../app/models";
import { getStore } from "../../../app/redux/slice/storeSlice";
import { StoreState } from "../../../app/models/storeModel";
import { RootState, store } from "../../../app/redux/store";

export interface InitialFormValues {
  firstName: string;
  email: string;
  timeslot: string | undefined;
  date: string | undefined;
}

interface AppointmentFormProps {
  formRef: React.RefObject<FormikProps<InitialFormValues>>;
}

const fakeTimeSlot = [
  new Date("August 09, 2021 08:30:00"),
  new Date("August 09, 2021 09:30:00"),
  new Date("August 09, 2021 10:30:00"),
  new Date("August 09, 2021 11:30:00"),
  new Date("August 09, 2021 13:30:00"),
  new Date("August 09, 2021 14:30:00"),
  new Date("August 09, 2021 15:30:00"),
  new Date("August 09, 2021 16:30:00"),
  new Date("August 09, 2021 17:30:00"),
  new Date("August 09, 2021 18:30:00"),
];

const AppointmentForm: React.FC<AppointmentFormProps> = ({ formRef }) => {
  // #region Redux
  var dispatch = useDispatch();
  const store = useSelector((state: RootState) => state.store);
  // #endregion

  const formikBookAppointment: FormikProps<InitialFormValues> =
    useFormik<InitialFormValues>({
      validationSchema: bookAppointmentSchema,
      initialValues: {
        firstName: "",
        email: "",
        timeslot: undefined,
        date: undefined,
      },
      onSubmit: (values) => {
        alert(JSON.stringify(values, null, 2));
      },
    });

  const handleCalendarTimeslotChange = (
    name: string,
    value: string,
    event: ChangeEvent<HTMLInputElement>
  ) => {
    name === "timeslot"
      ? formikBookAppointment.setValues(
          { ...formikBookAppointment.values, timeslot: value },
          true
        )
      : formikBookAppointment.setValues(
          { ...formikBookAppointment.values, date: value },
          true
        );
    formikBookAppointment.handleChange(event);
  };

  useEffect(() => {
    dispatch(getStore());
  }, []);

  return (
    <div className="form__container">
      <div className="form">
        <div className="form__calendar">
          <Calendar handleChange={handleCalendarTimeslotChange} />
          {formikBookAppointment.errors.date &&
          formikBookAppointment.touched.date ? (
            <div className="form__field-error">
              {formikBookAppointment.errors.date}
              <Warning className="form__field-error-logo" />
            </div>
          ) : null}
        </div>
        <div className="form__group">
          <div className="form__field-container">
            <input
              id="firstName"
              className={`form__field ${
                formikBookAppointment.errors.firstName !== ""
                  ? "form__field-error-highlight"
                  : ""
              }`}
              onChange={formikBookAppointment.handleChange("firstName")}
              onBlur={formikBookAppointment.handleBlur("firstName")}
              value={formikBookAppointment.values.firstName}
              name="firstName"
              placeholder="Enter your name"
            />
            {formikBookAppointment.errors.firstName &&
            formikBookAppointment.touched.firstName ? (
              <div className="form__field-error">
                {formikBookAppointment.errors.firstName}
                <Warning className="form__field-error-logo" />
              </div>
            ) : null}
          </div>
          <div className="form__field-container">
            <input
              id="email"
              className={`form__field ${
                formikBookAppointment.errors.email
                  ? "form__field-error-highlight"
                  : ""
              }`}
              name="email"
              onChange={formikBookAppointment.handleChange("email")}
              onBlur={formikBookAppointment.handleBlur("email")}
              value={formikBookAppointment.values.email}
              placeholder="Enter your email"
              type="email"
            />
            {formikBookAppointment.errors.email &&
            formikBookAppointment.touched.email ? (
              <div className="form__field-error">
                {formikBookAppointment.errors.email}
                <Warning className="form__field-error-logo" />
              </div>
            ) : null}
          </div>

          <div className="form__timeslot-container">
            <label className="book__label">
              {formikBookAppointment.errors.timeslot &&
              formikBookAppointment.touched.timeslot ? (
                <div className="form__field-timeslot-error">
                  {formikBookAppointment.errors.timeslot}
                  <Warning className="form__field-error-logo" />
                </div>
              ) : null}
            </label>
            <div className="timeslot">
              {store.storeInfo.timeslots.length === 0
                ? fakeTimeSlot.map((x, index) => (
                    <div key={index} className="timeslot__tile-container">
                      <Timeslot
                        value={x}
                        id={`radio${index}`}
                        handleChange={handleCalendarTimeslotChange}
                      />
                    </div>
                  ))
                : store.storeInfo.timeslots.map((x, index) => (
                    <div key={index} className="timeslot__tile-container">
                      <Timeslot
                        value={x}
                        id={`radio${index}`}
                        handleChange={handleCalendarTimeslotChange}
                      />
                    </div>
                  ))}
            </div>
          </div>
        </div>
      </div>
      <div className="form__book-button-container">
        <AppointmentButton
          buttonCSSStyle="form__book-button"
          buttonHTMLAttribute={{ type: "submit" }}
          onPress={() => {
            // if (handleErrors()) formikBookAppointment.handleSubmit();
            formikBookAppointment.handleSubmit();
          }}
        >
          Submit
        </AppointmentButton>
      </div>
    </div>
  );
};

export { AppointmentForm };
