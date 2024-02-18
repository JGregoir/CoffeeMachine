/* eslint-disable @typescript-eslint/no-unused-vars */
import { useEffect, useState } from 'react';
import './App.css';
import MachineStatus from './Components/MachineStatus';

const apiUrl: string = '/api/CoffeeActions';

function App() {

    useEffect(() => {
        populateCoffeLogs();
    }, []);

    const machineStates = ["Powered On", "Water Level", "Bean feed", "Waste coffee", "Water tray"];



    const handleSelectItem = (item: string) => {
        console.log(item);
        if (item === "POWER ON") {
            makePowerOnReq();
        }
    }


    return (
        <div>
            <p><MachineStatus items={machineStates} heading="Coffee Machine Status" onSelectItem={handleSelectItem} /></p>
        </div>
    );




    async function populateCoffeLogs() {

        console.log(apiUrl);
        const response = await fetch(apiUrl);

        console.log(response);
    }

    async function makePowerOnReq() {

        const url: string = apiUrl + "/reqPowerOn";

        console.log(url);
        const response = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-type': 'application/json'
            },
            body: JSON.stringify('TEST')
        });

        console.log(response);

    }
}

export default App;