import * as Yup from 'yup';

export const bookAppointmentSchema = Yup.object().shape({
  firstName: Yup.string()
    .min(2, 'Too Short!')
    .max(50, 'Too Long!')
    .required('Required'),
  email: Yup.string().email('Invalid email').required('Required'),
  timeslot: Yup.string().required('Required'),
  date: Yup.string().required('Required'),
});
