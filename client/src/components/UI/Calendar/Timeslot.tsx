import moment from 'moment';
import React, { ChangeEvent, useEffect, useState } from 'react';
import '../../../css/style.css';

interface TimeslotProps {
  value: string | any;
  id: string;
  handleChange: (
    name: string,
    value: string,
    event: ChangeEvent<HTMLInputElement>
  ) => void;
}

const Timeslot: React.FC<TimeslotProps> = ({
  value,
  id,
  handleChange = () => {},
}) => {
  const [radioValue, setRadioValue] = useState(value);

  useEffect(() => {
    setRadioValue(value);
  }, []);

  return (
    <div className="timeslot__radio-container">
      <input
        name="timeslot"
        type="radio"
        id={id}
        className="timeslot__radiobutton no-select"
        onChange={(e) => {
          handleChange('timeslot', radioValue, e);
        }}
        value={moment(radioValue! as Date).format('HH:mm')}
      />
      <label htmlFor={id} className="timeslot__tile">
        {moment(radioValue! as Date).format('hh:mm A')}
      </label>
    </div>
  );
};

export { Timeslot };
