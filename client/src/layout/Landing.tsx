import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { useHistory } from 'react-router-dom';
import { FrontLanding, Services } from '.';
import { locationState } from '../app/models';
import { getStore } from '../app/redux/slice/storeSlice';
import { RootState } from '../app/redux/store';

interface LandingProps {
  servicesRef: React.MutableRefObject<HTMLDivElement | null> | null;
  frontLandingRef: React.MutableRefObject<HTMLDivElement | null> | null;
}

const Landing: React.FC<LandingProps> = (props) => {
  const { frontLandingRef, servicesRef } = props;

  const history = useHistory<locationState>();

  useEffect(() => {
    if (
      history.location.state?.from?.pathname !== '/' &&
      history.location.state?.from?.ref !== null
    ) {
      history.location.state?.from?.ref?.current?.scrollIntoView({
        behavior: 'smooth',
        block: 'start',
        inline: 'nearest',
      });
    }
  });

  return (
    <>
      <FrontLanding frontlandingRef={frontLandingRef} />
      <Services servicesRef={servicesRef} />
    </>
  );
};

export { Landing };
