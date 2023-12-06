import React, {ReactElement, FC} from "react";
import {
    Box,
    Card,
    CardContent,
    CircularProgress,
    Container,
    Grid,
    Typography
} from '@mui/material'
import ResourceStore from "./ResourceStorePage";
import {observer} from "mobx-react-lite";
import {useParams} from "react-router-dom";

const store = new ResourceStore();

const ResourcePage: FC<any> = observer((): ReactElement => {
    const { id } = useParams();
    const resourceId = Number(id);

    if (store.resource === null || store.resource.id !== resourceId) {
        store.fetchResource(resourceId.toString());
    }

    return (
        <Container>
            <Grid container spacing={4} justifyContent="center" m={4}>
                {store.isLoading ? (
                    <CircularProgress />
                ) : (
                    <>
                        <Card sx={{ maxWidth: 250, backgroundColor: store.resource?.color }}> 
                            <CardContent>
                                <Typography noWrap gutterBottom variant="h6" component="div">
                                    {store.resource?.name}
                                </Typography>
                                <Typography variant="body2" color="text.secondary">
                                    Year: {store.resource?.year}
                                </Typography>
                                <Typography variant="body2" color="text.secondary">
                                    Color: {store.resource?.color}
                                </Typography>
                                <Typography variant="body2" color="text.secondary">
                                    Pantone Value: {store.resource?.pantone_value}
                                </Typography>
                            </CardContent>
                        </Card>
                    </>
                )}
            </Grid>
        </Container>
    );
});

export default ResourcePage;