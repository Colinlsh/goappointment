import { TimeType } from './enums';

export const IsSameDay = (d1: Date, d2: Date) => {
  return (
    d1.getFullYear() === d2.getFullYear() &&
    d1.getMonth() === d2.getMonth() &&
    d1.getDate() === d2.getDate()
  );
};

export const TimeDifference = (d1: Date, d2: Date, type: TimeType) => {
  var timeDiff = d1.getTime() - d2.getTime();

  var result;
  switch (type) {
    case TimeType.Days:
      // Get diff in days
      result = Math.floor(timeDiff / 1000 / 60 / 60 / 24);
      timeDiff -= result * 1000 * 60 * 60 * 24;
      break;
    case TimeType.Hours:
      // Get diff in hours
      result = Math.floor(timeDiff / 1000 / 60 / 60);
      timeDiff -= result * 1000 * 60 * 60;
      break;
    case TimeType.Minutes:
      // Get diff in minutes
      result = Math.floor(timeDiff / 1000 / 60);
      timeDiff -= result * 1000 * 60;
      break;
    case TimeType.Seconds:
      // Get diff in seconds
      result = Math.floor(timeDiff / 1000);
      break;

    default:
      break;
  }

  return result;
};
