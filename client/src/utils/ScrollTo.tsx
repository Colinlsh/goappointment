import { useEffect } from 'react';
import { useHistory, withRouter } from 'react-router-dom';
import { locationState } from '../app/models';

const ScrollTo = ({ children, location: { pathname } }: any) => {
  const history = useHistory<locationState>();

  useEffect(() => {
    if (history.location.state?.from?.pathname !== '/') {
      history.location.state?.from?.ref?.current?.scrollIntoView({
        behavior: 'smooth',
        block: 'start',
        inline: 'nearest',
      });
    } else {
      window.scrollTo(0, 0);
    }
  });

  return children || null;
};

export default withRouter(ScrollTo);
