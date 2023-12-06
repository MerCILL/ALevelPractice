import { Container, TextField, Button, Box } from "@mui/material";
import { FC } from "react";
import CreateUserStore from "./CreateUserStore";
import { observer } from "mobx-react-lite";

const store = new CreateUserStore();

const CreateUser: FC = observer(() => {
    const handleSubmit = (event: React.FormEvent) => {
        event.preventDefault();
        store.createUser();
    };

    return (
        <Container>
            <Box
                component="form"
                sx={{
                    '& .MuiTextField-root': { m: 1, width: '25ch' },
                }}
                noValidate
                autoComplete="off"
                onSubmit={handleSubmit}
            >
                <TextField
                    error={store.error.name}
                    helperText={store.error.name ? "Name is required" : ""}
                    label="Name"
                    value={store.name}
                    onChange={(e) => store.setName(e.target.value)}
                    required
                    sx={{ mb: 2 }}
                />
                <TextField
                    error={store.error.job}
                    helperText={store.error.job ? "Job is required" : ""}
                    label="Job"
                    value={store.job}
                    onChange={(e) => store.setJob(e.target.value)}
                    required
                    sx={{ mb: 2 }}
                />
                <Button 
                    type="submit" 
                    variant="contained" 
                    color="success"
                    sx={{ 
                        m: 1, 
                        width: '25ch', 
                        pt: '6px',
                        pb: '6px',
                        fontSize: '25px'
                    }}
                >
                    CREATE
                </Button>
            </Box>
        </Container>
    );
});

export default CreateUser;