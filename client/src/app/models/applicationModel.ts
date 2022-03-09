import React from 'react';

export interface ApplicationState {
  refViews: Array<RefView>;
  commonModal: CommonModal;
  error: any;
}

export interface CommonModal {
  title: string;
  message: Array<ModalErrorModel>;
  isVisible: boolean;
}

export interface ModalErrorModel {
  field: string;
  message: string;
}

export interface RefView {
  name: string;
  refView: React.MutableRefObject<HTMLDivElement | null>;
}

export interface locationState {
  from: {
    pathname: string;
    ref: React.MutableRefObject<HTMLDivElement | null> | null;
  };
}
