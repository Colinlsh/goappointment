import React, { ChangeEvent, useState } from 'react';
import RCalendar from 'react-calendar';
import '../../../css/style.css';
import '../../../css/calendar.css';
import moment from 'moment';
import { useSelector } from 'react-redux';
import { RootState } from '../../../app/redux/store';
import { IsSameDay } from '../../../app/common/utils/utils';

interface CalendarProps {
  handleChange: (
    name: string,
    value: string,
    event: ChangeEvent<HTMLInputElement>
  ) => void;
}

const Calendar: React.FC<CalendarProps> = ({ handleChange }) => {
  const [date, setDate] = useState<Date | undefined>(new Date());

  // #region Redux
  const store = useSelector((state: RootState) => state.store);
  // #endregion

  React.useEffect(() => {
    // call out dispatch to backend for current day timeslot
  }, []);

  return (
    <>
      <RCalendar
        onChange={(value: Date, event: ChangeEvent<HTMLInputElement>) => {
          setDate(value);
          handleChange('date', moment(value).format('YYYY-MM-DD'), event);
        }}
        value={date}
        tileClassName="react-calendar__tile-custom"
        minDate={new Date()}
        maxDetail={'month'}
        tileDisabled={({ date, activeStartDate, view }) => {
          var disable = false;

          if (store.storeInfo.disabledDays.some((x) => date.getDay() === x))
            disable = true;
          if (
            store.storeInfo.disabledDates.some((c) =>
              IsSameDay(new Date(c), new Date(date))
            )
          )
            disable = true;
          if (
            store.storeInfo.disabledSpecialDates.some((c) =>
              IsSameDay(new Date(c), new Date(date))
            )
          )
            disable = true;

          return disable;
        }}
      />
    </>
  );
};

export { Calendar };
