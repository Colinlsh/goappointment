import React from 'react';

const DashboardScreen = () => {
  return (
    <div
      style={{
        display: 'flex',
        flex: 5,
        flexDirection: 'column',
        columnCount: 1,
        width: '100%',
      }}
    >
      <div
        style={{
          display: 'flex',
          width: 'inherit',
          flex: 1,
          height: '5vh',
          minHeight: 40,
          position: 'absolute',
          top: 0,
          zIndex: 100,
          backgroundColor: '#EC9706',
          textAlign: 'left',
          alignContent: 'center',
        }}
      >
        <text
          style={{
            margin: 10,
            color: 'white',
          }}
        >
          Tenant Name
        </text>
      </div>
      <div
        style={{
          flex: 4,
          marginTop: '5vh',
        }}
      >
        <div
          style={{
            display: 'flex',
            flexDirection: 'row',
          }}
        >
          <div
            style={{
              backgroundColor: 'red',
              minWidth: 100,
              width: '10vw',
            }}
          ></div>
          <div style={{ backgroundColor: 'blue', flex: 1 }}>
            <text>haha</text>
          </div>
        </div>
      </div>
    </div>
  );
};

export { DashboardScreen };
