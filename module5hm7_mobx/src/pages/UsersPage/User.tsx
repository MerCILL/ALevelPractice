import React, {ReactElement, FC} from "react";
import {
    Box,
    Card,
    CardContent,
    CardMedia,
    CircularProgress,
    Container,
    Grid,
    Pagination,
    Typography
} from '@mui/material'
import UserStore from "./UserStore";
import {observer} from "mobx-react-lite";
import {useParams} from "react-router-dom";

const store = new UserStore();

const User: FC<any> = observer((): ReactElement => {
    const { id } = useParams();
    const userId = Number(id);

    if (store.user === null || store.user.id !== userId) {
        store.fetchUser(userId.toString());
    }

    return (
        <Container>
            <Grid container spacing={4} justifyContent="center" m={4}>
                {store.isLoading ? (
                    <CircularProgress />
                ) : (
                    <>
                        <Card sx={{ maxWidth: 250 }}>
                            <CardMedia
                                component="img"
                                height="250"
                                image={store.user?.avatar}
                                alt={store.user?.email}
                            />
                            <CardContent>
                                <Typography noWrap gutterBottom variant="h6" component="div">
                                    {store.user?.email}
                                </Typography>
                                <Typography variant="body2" color="text.secondary">
                                    {store.user?.first_name} {store.user?.last_name}
                                </Typography>
                            </CardContent>
                        </Card>
                    </>
                )}
            </Grid>
        </Container>
    );
});

export default User;