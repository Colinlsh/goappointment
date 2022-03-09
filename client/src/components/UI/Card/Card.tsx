import React from 'react';

import classes from './Card.module.css';

interface CardProps {
  classname?: string | undefined;
}

const Card = ({ classname, children }: React.PropsWithChildren<CardProps>) => {
  return <div className={`${classes.card} ${classname}`}>{children}</div>;
};

export { Card };
