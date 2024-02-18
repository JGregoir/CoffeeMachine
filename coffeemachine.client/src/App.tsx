/* eslint-disable @typescript-eslint/no-unused-vars */
import { useEffect, useState } from 'react';
import './App.css';
import MachineStatus from './Components/MachineStatus';

const apiUrl: string = '/api/CoffeeActions';

interface Log {
    // too late to change, but indexing with timestamp lead to conflicting Index. 
    // need to replace first column with CoffeeAction Index, unique by design.
    timeStamp: string;
    quantity: number;
}
function App() {


    const [logs, setLogs] = useState<Log[]>();

    useEffect(() => {
        populateCoffeLogs();
    }, []);

    const machineStates = ["Powered On", "Water Level", "Bean feed", "Waste coffee", "Water tray"];


    const handleSelectItem = (item: string) => {
        console.log(item);
        if (item === "POWER ON") {
            makeReq("reqPowerON");
        }
        if (item === "POWER OFF") {
            makeReq('reqPowerOFF');
        }
        if (item === "COFFEE") {
            makeReq("reqCoffee");
            populateCoffeLogs();
        }
    }

    // def of log display :

    const logContents = logs === undefined
        ? <p><em>Loading...</em></p>
        : <table className="table table-striped" aria-labelledby="tableLabel">
            <thead>
                <tr>
                    <th>Date</th>
                    <th>number of coffees</th>
                </tr>
            </thead>
            <tbody>
                {logs.map(logs =>
                    <tr key={logs.timeStamp}>
                        <td>{logs.timeStamp}</td>
                        <td>{logs.quantity}</td>
                    </tr>
                )}
            </tbody>
        </table>;


    return (
        <div>
            <p><MachineStatus items={machineStates} heading="Coffee Machine Status" onSelectItem={handleSelectItem} /></p>
            <h1 id="tableLabel">Logs table</h1>
            {logContents}
        </div>
    );

//request formatting :
    async function populateCoffeLogs() {

        console.log(apiUrl);
        const response = await fetch(apiUrl+"/Log");
        const data = await response.json();
        setLogs(data);
        console.log(response);
        console.log(data);
    }

    async function makeReq(str: string) {

        const url: string = apiUrl + "/" + str;

        console.log(url);
        const response = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-type': 'application/json'
            },
            body: JSON.stringify('')
        });

        console.log(response);

    }
}

export default App;