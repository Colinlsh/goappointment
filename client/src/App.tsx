import React, { useRef } from "react";

import { BrowserRouter as Router, Route, Switch } from "react-router-dom";

import "./css/style.css";
import { AppointmentCommonModal, AppointmentNavDrawer } from "./components/UI";
import { Book, Footer, Landing } from "./layout";
import ScrollTo from "./utils/ScrollTo";

function App() {
  const servicesRef = useRef<HTMLDivElement | null>(null);
  const frontLandingRef = useRef<HTMLDivElement | null>(null);

  return (
    <Router>
      <ScrollTo>
        <div className="app">
          <AppointmentCommonModal />
          <AppointmentNavDrawer
            servicesRef={servicesRef}
            frontLandingRef={frontLandingRef}
          />
          <Switch>
            <Route exact path="/goappointment/">
              <Landing
                servicesRef={servicesRef}
                frontLandingRef={frontLandingRef}
              />
            </Route>
            <Route exact path="/goappointment/book">
              <Book />
            </Route>
          </Switch>
          <Footer />
        </div>
      </ScrollTo>
    </Router>
  );
}

export default App;
