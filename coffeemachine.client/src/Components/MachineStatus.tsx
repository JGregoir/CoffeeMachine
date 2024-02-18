


//this props should be static content in the component, I did not have time to reintegrate the array in App.tsx
//It would be better to use it as a Props to import the coffee machine states definition from the server.

interface Props {
    items: string[];
    heading: string;
    onSelectItem: (item: string) => void
}

function MachineStatus({items, heading, onSelectItem }: Props) {

    return (
        <>
            <p>{heading}</p>
            {items.length === 0 ? <p>No item found</p> : null}
            <ul className="list-group">
                {
                    items.map((item) => (
                    <li style={{ cursor: "pointer" }} className={'list-group-item'}
                    key={item} >
                    {item}
                    </li>
                    ))
                }
            </ul>

            <hr></hr>
            
            <button className="btn btn-primary"
                onClick={() => { onSelectItem("POWER ON"); }}> 
                Turn ON
            </button>
            {' '}
            <button className="btn btn-primary"
                onClick={() => { onSelectItem("POWER OFF"); }}>
                Turn OFF
            </button>
            {' '}
            <button className="btn btn-primary"
                onClick={() => { onSelectItem("COFFEE"); }}>
                MakeCoffee
            </button>

        </>
    );
}

export default MachineStatus;