
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
                onClick={() => { onSelectItem("POWER ON"); }}>
                MakeCoffee
            </button>

        </>
    );
}

export default MachineStatus;