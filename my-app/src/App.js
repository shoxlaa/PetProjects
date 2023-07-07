import logo from './logo.svg';
import './App.css';
import { Button } from 'react-bootstrap';
import MyNavBar from './Components/MyNavBar';

function App() {
  return (
    <div className="App">
    <header className="App-header">
    <MyNavBar></MyNavBar>

    <div>
      <div>
      <div> Doctor action  </div>
     <Button> Add Doctor </Button>
     <Button> Delete Doctor</Button>
     <Button> Edit Doctor Info </Button>
     <Button> Delete Doctor</Button> 

     <div>Client action</div>
     <Button>Make an appointment</Button>
     <Button>Change reg </Button>
     <Button>Delete reg</Button>

      </div>
      <div>
      
      </div>
       </div>
    
    </header>
  </div>
);
}

export default App;
