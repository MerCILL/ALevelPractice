import React, {ReactElement, FC, useEffect} from "react";
import {Box, Button, CircularProgress, Container, Grid, Pagination} from '@mui/material'
import HomeStore from "./HomeStore";
import {observer} from "mobx-react-lite";
import UserCard from "./components/UserCard";
import { useNavigate } from "react-router-dom";

const store = new HomeStore();

const Home: FC<any> = (): ReactElement => {
    const navigate = useNavigate();
  return (
      <Container>
          <Grid container spacing={4} justifyContent="center" my={4}>
              {store.isLoading ? (
                  <CircularProgress />
              ) : (
                  <>
                      {store.users?.map((item) => (
                          <Grid key={item.id} item lg={2} md={3} xs={6}>
                              <UserCard {...item} />
                          </Grid>
                      ))}
                  </>
              )}
          </Grid>
          <Box
              sx={{
                  display: 'flex',
                  justifyContent: 'center'
              }}
          >
              <Pagination count={store.totalPages}
                          page={store.currentPage}
                          onChange={ async (event, page)=> await store.changePage(page)} />
          </Box>
          <Button 
            onClick={() => navigate('/create-user')} 
            variant="contained" 
            color="primary"
            sx={{ 
                mt: 2,
                mb: 2,
                width: '100%',
                height: '50px',
                fontSize: '20px',
                fontWeight: 'bold',
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center'
            }}
            size="large"
            >
            Create User
            </Button>
      </Container>
  );
};

export default observer(Home);


